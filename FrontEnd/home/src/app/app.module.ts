import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistorComponent } from './registor/registor.component';
import { ProfileComponent } from './profile/profile.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MatchComponent } from './match/match.component';
import { LikeComponent } from './like/like.component';
import { PassComponent } from './pass/pass.component';
import { NotFoundError } from 'rxjs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChatComponent } from './chat/chat.component';
import { UserComponent } from './user/user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ProfileComponent,
    NavBarComponent,
    MatchComponent,
    LikeComponent,
    RegistorComponent,
    PassComponent,
    ChatComponent,
    UserComponent,
    NavBarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,

    
    RouterModule.forRoot([
      // { path: "", redirectTo: "/login", pathMatch: "full" },
      {path: "Profile/:userName", component: ProfileComponent}, 
      {path: "Profile/Match", component: MatchComponent}, 
      {path: "Profile/Pass", component:PassComponent},
      {path: "Profile/Like", component: LikeComponent},
      {path: "Login", component: LoginComponent},
      {path: "Registor", component: RegistorComponent},
      {path: "", component:ProfileComponent}, 
      {path: "**", component:NotFoundError} 
    ]),

    
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
