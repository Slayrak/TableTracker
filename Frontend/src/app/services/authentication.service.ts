import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthResponseDTO } from '../models/dtos/auth-response.dto';
import { UserForAuthenticationDTO } from '../models/dtos/user-for-authentication.dto';
import { Subject } from 'rxjs';
import { UserForSignupDTO } from '../models/dtos/user-for-signup.dto';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  
  private authChangeSub = new Subject<boolean>()
  public authChanged = this.authChangeSub.asObservable();

  constructor(private http: HttpClient) { }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  }

  public loginUser = (body: UserForAuthenticationDTO) => {
    return this.http.post<AuthResponseDTO>('https://localhost:5001/api/accounts/login', body);
  }

  public signUpUser = (body: UserForSignupDTO) => {
    return this.http.post('https://localhost:5001/api/accounts/signup', body);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }
}
