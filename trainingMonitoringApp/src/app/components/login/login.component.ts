import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModules } from '../../material/material.module';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, MaterialModules],
})
export class LoginComponent {
  loginModel = { email: '', password: '' };
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onLogin() {
    this.authService.login(this.loginModel).subscribe(
      (response: any) => {
        this.authService.saveToken(response.token);
        this.router.navigate(['/dashboard']);
      },
      (error) => {
        this.errorMessage = 'Invalid email or password';
      }
    );
  }
}
