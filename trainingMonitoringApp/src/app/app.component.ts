import { Component, NgZone, OnInit } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  constructor(
    private authService: AuthService,
    // private userService: UserService,
    private _ngZone: NgZone,
    private router: Router
  ) {}
  ngOnInit(): void {
    const isLoggedIn = this.authService.isAuthenticated();
    /*if (isLoggedIn) {
      this.userService.getUserInfo();
    }
      */
  }

  logout() {
    this.authService.removeToken();
    this._ngZone.run(() => {
      this.router.navigate(['/']).then(() => {
        window.location.reload();
      });
    });
  }
}
