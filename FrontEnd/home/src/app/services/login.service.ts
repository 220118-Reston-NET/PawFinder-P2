import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class LoginService {

  constructor(private http:HttpClient) { }

  verifyUser(userNameLogin:string, userPasswordLogin:string)
  {
    return this.http.get("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/LogIn?UserNameInput="+userNameLogin+"&PasswordInput="+userPasswordLogin);
  }

}
