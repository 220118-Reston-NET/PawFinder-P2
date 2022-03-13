import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Users } from '../models/users.model';

@Injectable({
  providedIn: 'root'
})

export class LoginService {

  constructor(private http:HttpClient) { }

  verifyUser(userNameLogin: string, userPasswordLogin: string)
  {

    // let params = new HttpParams();
    // params.append("UserNameInput", userNameLogin);
    // params.append("PasswordInput", userPasswordLogin);

    return this.http.get("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/LogIn?UserNameInput=" + userNameLogin +"&PasswordInput=" + userPasswordLogin);
  }

}
