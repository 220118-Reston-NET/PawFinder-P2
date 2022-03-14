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
  getAllUsers(): Observable<Users[]>
  {
    return this.http.get<Users[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetAllUsers");
  }
  getAllMatch():Observable<Match[]>
  {
    return this.http.get<Match[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/ViewMatchedUser?userID=1");
  }
   public uploadfile(file: File) 
   {
        let formParams = new FormData();
        formParams.append('file', file)
        return this.http.post('https://pawfinderwebapp.azurewebsites.net/api/PawFinder/RegisterUser', formParams)
   }
}
