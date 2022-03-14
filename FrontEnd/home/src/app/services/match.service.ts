import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { Users } from '../models/users.model';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  constructor(private http:HttpClient) { }

  getMatches(userID:number): Observable<Users[]>
  {
    return this.http.get<Users[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/ViewMatchedUser?userID="+userID);
  }

}
