import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SearchComponent } from './components/search/search.component';
import { LoginComponent } from './components/login/login.component';
import { SigninComponent } from './components/signin/signin.component';
import { ReserpasswordComponent } from './components/reserpassword/reserpassword.component';
import { FaqComponent } from './components/faq/faq.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { ManagerProfileComponent } from './components/manager-profile/manager-profile.component';

const routes: Routes = [
  { path: 'user/profile', component: UserProfileComponent },
  { path: 'manager/profile', component: ManagerProfileComponent },
  { path: 'home', component: HomeComponent },
  { path: 'search', component: SearchComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'resetpassword', component: ReserpasswordComponent },
  { path: 'faq', component: FaqComponent },
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
