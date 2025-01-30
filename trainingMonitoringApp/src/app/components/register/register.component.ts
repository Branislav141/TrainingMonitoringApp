import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MaterialModules } from '../../material/material.module';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, MaterialModules],
})
export class RegisterComponent {
  registerModel = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    gender: 'male',
  };
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onRegister() {
    this.authService.register(this.registerModel).subscribe(
      (response: any) => {
        this.router.navigate(['/login']);
      },
      (error) => {
        this.errorMessage = 'Registration failed. Please try again.';
      }
    );
  }
}
