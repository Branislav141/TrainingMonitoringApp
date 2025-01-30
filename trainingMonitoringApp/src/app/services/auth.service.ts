import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local.storage.service';
import { TokenEntity } from '../entity/token.entity';
import { API_URL } from '../environments/environment ';
import { LoginModel } from '../entity/loginModel';
import { RegisterModel } from '../entity/registerModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly ACCESS_TOKEN_KEY = 'access_token';

  constructor(
    private localStorageService: LocalStorageService,
    private http: HttpClient
  ) {}

  saveToken(token: TokenEntity): void {
    this.localStorageService.setItem(this.ACCESS_TOKEN_KEY, token.accessToken);
  }

  removeToken(): void {
    this.localStorageService.removeItem(this.ACCESS_TOKEN_KEY);
  }

  isAuthenticated(): boolean {
    const token = this.localStorageService.getItem(this.ACCESS_TOKEN_KEY);
    return token !== null;
  }

  getToken(): string | null {
    return this.localStorageService.getItem(this.ACCESS_TOKEN_KEY);
  }

  login(credentials: LoginModel): Observable<TokenEntity> {
    return this.http.post<TokenEntity>(`${API_URL}/auth/login`, credentials);
  }

  register(credentials: RegisterModel): Observable<any> {
    return this.http.post<any>(`${API_URL}/auth/register`, credentials);
  }
}
