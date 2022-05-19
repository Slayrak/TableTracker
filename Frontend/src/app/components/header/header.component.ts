import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  
  public isUserAuthenticated!: boolean;

  constructor(private router: Router, private authService: AuthenticationService) { }

  ngOnInit(): void {
    this.authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    });
  }

  logout() {
    this.authService.logout();
       
    this.router.navigate(['/home']);
  }

}
