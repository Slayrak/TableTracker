import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { VisitorDTO } from 'src/app/models/dtos/visitor.dto';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  user: VisitorDTO | null = null;

  constructor(private router: Router, private authService: AuthenticationService) { }

  ngOnInit(): void {
    if (localStorage['user'] !== undefined && localStorage['user'] !== null) {
      this.user = JSON.parse(localStorage['user']);
    }
  }

  logout() {
    this.authService.logout();
       
    this.router.navigate(['/home']);
  }

  goToProfile() {
    this.router.navigate(['user', this.user!.id, 'profile']);
  }

  isLoggedIn(): boolean {
    return localStorage['user'] !== undefined && localStorage['user'] !== null
  }

}
