import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GlobalComponent } from '../global/global.component';
import { Message } from '../models/message.model';
import { User } from '../models/users.model';
import { ChatService } from '../services/chat.service';
import { NavbarService } from '../services/navbar.service';
import { PawfinderService } from '../services/pawfinder.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  listOfMessages:Message[];
  myUserID = GlobalComponent.loggedInUserID;
  myUserName = GlobalComponent.loggedInUserName;
  chattingUserID = 0;
  chattingUserName = "";
  numOfMessages: number = 0;

  messageGroup = new FormGroup({
    messageText: new FormControl("") 
  })

  constructor(private router:ActivatedRoute , private PawService:PawfinderService, private userService:UserService, private chatService:ChatService, public nav: NavbarService) {
    this.listOfMessages = [];
  }
 
    ngOnInit(): void {
      this.nav.show();

      this.chattingUserID = GlobalComponent.chattingUserID;

      this.userService.getUserByUserID(this.chattingUserID).subscribe(result => 

        {
          let user:User=
          {
            UserID: result.UserID,
            UserName:result.UserName,
            UserPassword:"",
            UserDOB: new Date,
            UserBio:"",
            UserBreed:"",
            UserSize:"",
            pictureURL:""
          }
          
          this.chattingUserName = user.UserName;

          this.chatService.getConveration(this.myUserID, this.chattingUserID).subscribe(result => {console.log(result); this.listOfMessages = result; console.log(result.length); this.numOfMessages=result.length});
        });

    }

    loadConveration()
    {
      this.chatService.getConveration(this.myUserID, this.chattingUserID).subscribe(result => {this.listOfMessages = result});
    }

    sendMessage(p_messageGroup:FormGroup)
    {

      let messageGroup:Message = 
      {
        messageID: 0,
        senderID: this.myUserID,
        receiverID: this.chattingUserID,
        messageText: p_messageGroup.get("messageText")?.value,
        messageTimeStamp: new Date
      }

      this.chatService.sendMessage(messageGroup).subscribe( () => {this.loadConveration()} );
      this.messageGroup.reset({messageText: ""})

    }

}
