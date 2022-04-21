import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { User } from '../models/users.model';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  constructor(private http:HttpClient) { }

  getMatches(userID:number): Observable<User[]>
  {
    return this.http.get<User[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/ViewMatchedUser?userID="+userID);
  }

}
