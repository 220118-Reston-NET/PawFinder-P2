import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/users.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  addUser(user:User)
  {
    return this.http.post<User>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/RegisterUser", user);
  }

  updateUser(user: User)
  {
    return this.http.put<User>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/UpdateUserBioSize", user);
  }

  getPotentialMatch(p_userID:number): Observable<User[]>
  {
    return this.http.get<User[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetPotentialMatch?UserID=" + p_userID)
  }

  getAllUsers(): Observable<User[]>
  {
    return this.http.get<User[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetAllUsers");
  }

  getUserByUserID(p_userID:number): Observable<User>
  {
    return this.http.get<User>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetUser?userID="+p_userID);
  }

  getUserByUserName(p_userName:string): Observable<User>
  {
    return this.http.get<User>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetUserByUsername?userName="+p_userName);
  }

  getLikeToDislikeRatio(p_userID:number): Observable<number[]>
  {
    return this.http.get<number[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetLikeToDislikeRatio?userID="+p_userID);
  }

}
