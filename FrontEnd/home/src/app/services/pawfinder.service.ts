import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Match } from '../models/match.model';
import { Users } from '../models/users.model';

@Injectable({
  providedIn: 'root'
})
export class PawfinderService {

  constructor(private http:HttpClient) { }
  getAllUsers()
  {
    return this.http.get<Users[]>("Url");
  }
  getAllMatch()
  {
    return this.http.get<Match[]>("url");
  }
}
