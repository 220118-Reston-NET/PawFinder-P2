import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Users } from '../models/users.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  // verifyUser()
  // {
  //   //some functionality to verify a user (could just be through verifying email and pw for now).
  //   return this.http.get<Users>("https://")
  // }

  addUser(user:Users)
  {
    return this.http.post<Users>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/RegisterUser", user);
  }

}
