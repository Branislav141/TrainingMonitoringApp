import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { MaterialModules } from '../../material/material.module';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, MaterialModules],
})
export class DashboardComponent implements OnInit {
  user: any = {};
  loading: boolean = true;
  error: string = '';

  constructor(
    private currentUserService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.currentUserService.getCurrentUser().subscribe(
      (data) => {
        this.user = data;
        this.loading = false;
      },
      (err) => {
        this.error = 'Error fetching user data';
        this.loading = false;
      }
    );
  }

  logout(): void {
    localStorage.removeItem('jwt_token');

    this.router.navigate(['/login']);
  }
}
