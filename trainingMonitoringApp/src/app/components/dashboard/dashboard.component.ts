import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from '../../services/user.service';
import { ExerciseService } from '../../services/exercise.service';
import { ExerciseModalComponent } from '../exercise-modal/exercise-modal.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModules } from '../../material/material.module';
import { Router } from '@angular/router';
import { ExerciseListModalComponent } from '../exercise-list/exercise-list.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, MaterialModules],
})
export class DashboardComponent implements OnInit {
  user: any = {};
  loading = true;
  error: string = '';
  exercises: any[] = [];

  constructor(
    private userService: UserService,
    private exerciseService: ExerciseService,
    private router: Router,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadUserData();
  }

  loadUserData(): void {
    this.userService.getCurrentUser().subscribe(
      (data: any) => {
        this.user = data;
        this.loading = false;
      },
      (error: any) => {
        this.error = 'Failed to load user data';
        this.loading = false;
      }
    );
  }

  openExerciseModal(): void {
    const dialogRef = this.dialog.open(ExerciseModalComponent, {
      width: '400px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('Exercise modal closed', result);
    });
  }

  viewAllExercises(): void {
    this.loading = true;
    this.exerciseService.getAllExercises().subscribe(
      (data) => {
        this.exercises = data;
        this.loading = false;
        this.openExerciseListModal();
      },
      (error) => {
        this.error = 'Error loading exercises';
        this.loading = false;
      }
    );
  }

  openExerciseListModal(): void {
    const dialogRef = this.dialog.open(ExerciseListModalComponent, {
      data: { exercises: this.exercises },
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(() => {
      console.log('Exercise list modal closed');
    });
  }

  createWorkout(): void {
    console.log('Create workout clicked');
  }

  logout(): void {
    localStorage.removeItem('jwt_token');
    this.router.navigate(['/login']);
  }
}
