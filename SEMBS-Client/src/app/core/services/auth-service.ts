import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { RegisterRequest } from "../../shared/models/auth/register-request.model";
import { LoginRequest } from "../../shared/models/auth/login-request.model";
import { LoginResponse } from "../../shared/models/auth/login-response.model";

@Injectable({ providedIn: 'root' })
export class AuthService {

  constructor(private http: HttpClient) { }

  private apiUrl = 'https://localhost:44306/api/auth';

  register(req: RegisterRequest) {
    return this.http.post(`${this.apiUrl}/register`, req);
  }
  login(request: LoginRequest) {
    return this.http.post<any>(`${this.apiUrl}/login`, request);
  }

  setSession(res: LoginResponse) {
  localStorage.setItem('token', res.accessToken);
  localStorage.setItem('role', res.role);
  localStorage.setItem('userId', res.userId.toString());
}


  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getRole(): string | null {
    return localStorage.getItem('role');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  logout() {
    localStorage.clear();
  }
}
