import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message } from '../models/message.model';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private http:HttpClient) { }

  getConveration(p_myUserID:number, p_chattingWithUserID:number): Observable<Message[]>
  {
    return this.http.get<Message[]>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/GetConversation?UserID1="+p_myUserID+"&UserID2="+p_chattingWithUserID);
  }

  sendMessage(message:Message)
  {
    return this.http.post<Message>("https://pawfinderwebapp.azurewebsites.net/api/PawFinder/AddMessage", message)
  }

}
