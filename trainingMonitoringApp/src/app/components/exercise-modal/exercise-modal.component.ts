import { Component, EventEmitter, Output } from '@angular/core';
import { ExerciseService } from '../../services/exercise.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModules } from '../../material/material.module';
import { MatDialogRef } from '@angular/material/dialog';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ExerciseModel } from '../../models/exerciseModel';

@Component({
  selector: 'app-exercise-modal',
  templateUrl: './exercise-modal.component.html',
  styleUrls: ['./exercise-modal.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, MaterialModules],
})
export class ExerciseModalComponent {
  @Output() close = new EventEmitter<void>();

  newExercise: ExerciseModel = {
    exerciseName: '',
    duration: 0,
    caloriesBurned: 0,
    exerciseType: 'cardio',
  };

  constructor(
    private http: HttpClient,
    private exerciseService: ExerciseService,
    private dialogRef: MatDialogRef<ExerciseModalComponent>
  ) {}

  onCreateExercise(): void {
    this.exerciseService.createExercise(this.newExercise).subscribe(
      (response) => {
        console.log('Exercise created successfully', response);
        this.dialogRef.close(response);
      },
      (error) => {
        console.error('Error creating exercise', error);
      }
    );
  }

  onClose(): void {
    this.dialogRef.close();
  }
}
