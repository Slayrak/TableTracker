import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthResponseDTO } from '../models/dtos/auth-response.dto';
import { UserForAuthenticationDTO } from '../models/dtos/user-for-authentication.dto';
import { UserForSignupDTO } from '../models/dtos/user-for-signup.dto';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  public loginUser = (body: UserForAuthenticationDTO) => {
    return this.http.post<AuthResponseDTO>('https://localhost:5001/api/accounts/login', body);
  }

  public forgotPassword = (body: {email: string}) => {
    return this.http.post('https://localhost:5001/api/accounts/forgot-password', body);
  }

  public signUpUser = (body: UserForSignupDTO) => {
    return this.http.post('https://localhost:5001/api/accounts/signup', body);
  }

  public logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("userId");
  }
}
