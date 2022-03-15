import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Users } from '../models/users.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  addUser(user:Users)
  {
    return this.http.post<Users>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/RegisterUser", user);
  }

  updateUser(user: Users)
  {
    return this.http.put<Users>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/UpdateUserBioSize", user);
  }

  getPotentialMatch(p_userID:number)
  {
    return this.http.get("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetPotentialMatch?UserID=" + p_userID)
  }

  getAllUsers(): Observable<Users[]>
  {
    return this.http.get<Users[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetAllUsers");
  }

  getUserByUserID(p_userID:number): Observable<Users>
  {
    return this.http.get<Users>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetUser?userID="+p_userID);
  }

  getUserByUserName(p_userName:string): Observable<Users>
  {
    return this.http.get<Users>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetUserByUsername?userName="+p_userName);
  }

}
