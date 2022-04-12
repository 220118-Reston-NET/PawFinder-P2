import { RouterModule } from '@angular/router';
import { NgModule, Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import { HomePageComponent } from './home-page/home-page.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistorComponent } from './registor/registor.component';
import { ProfileComponent } from './profile/profile.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MatchComponent } from './match/match.component';
import { LikeComponent } from './like/like.component';
import { PassComponent } from './pass/pass.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChatComponent } from './chat/chat.component';
import { UserComponent } from './user/user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotFoundError } from 'rxjs';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GlobalComponent } from './global/global.component';
import { LikeDislikeRatioGraphComponent } from './like-dislike-ratio-graph/like-dislike-ratio-graph.component';
import { NgChartsModule } from 'ng2-charts';




@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginComponent,
    ProfileComponent,
    NavBarComponent,
    MatchComponent,
    LikeComponent,
    RegistorComponent,
    PassComponent,
    ChatComponent,
    UserComponent,
    HomePageComponent,
    NavBarComponent,
    GlobalComponent,
    LikeDislikeRatioGraphComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule,

    
    RouterModule.forRoot([
      // { path: "", redirectTo: "/login", pathMatch: "full" },
      {path: "HomePage", component: HomePageComponent}, 
      {path: "Profile", component: ProfileComponent}, 
     {path: "Users", component: UserComponent},
      {path: "Match", component: MatchComponent}, 
      {path: "Pass", component:PassComponent},
      {path: "Chat", component:ChatComponent},
      {path: "Like", component: LikeComponent},
      {path: "Login", component: LoginComponent},
      {path: "Registor", component: RegistorComponent},
      {path: "", component:LoginComponent}, 
      {path: "**", component:NotFoundError} 
    ]),

    
    BrowserAnimationsModule,

    
    NgChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
