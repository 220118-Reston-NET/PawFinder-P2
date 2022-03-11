import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Users } from '../models/users.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  verifyUser(user: Users)
  {
    return this.http.get<Users>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/LogIn");
  }

  addUser(user:Users)
  {
    return this.http.post<Users>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/RegisterUser", user);
  }

}
