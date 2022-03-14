import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LikeService {

  constructor(private http:HttpClient) { }

  likeAUser(likeeID:number, likerID:number)
  {
    return this.http.post("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/AddLikedUser?LikerID="+likerID+"&LikedID="+likeeID, likeeID);
  }

  DislikeAUser(passeeID:number, passerID:number)
  {
    return this.http.post("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/AddPassedUserID?passerID="+passerID+"&passeeID="+passeeID, passeeID);
  }

}
