import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SearchComponent } from './components/search/search.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { FaqComponent } from './components/faq/faq.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { ManagerProfileComponent } from './components/manager-profile/manager-profile.component';
import { RestaurantPageComponent } from './components/restaurant-page/restaurant-page.component';

const routes: Routes = [
  { path: 'user/:id/profile', component: UserProfileComponent },
  { path: 'manager/profile/:id', component: ManagerProfileComponent },
  { path: 'home', component: HomeComponent },
  { path: 'search', component: SearchComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'faq', component: FaqComponent },
  { path: 'restaurant-page/:id', component: RestaurantPageComponent },
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
