import { PawfinderService } from './../services/pawfinder.service';
import { User } from './../models/users.model';
import { Component, OnInit } from '@angular/core';
import { faStar } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  title:string = "List of Users";
    src1:string = "https://upload.wikimedia.org/wikipedia/commons/6/6a/Door_Tree_1898.png";
    isVisible:boolean = true;

    filteredName:string = "";

    listOfUsers:User[];
    filteredListOfUser:User[];
    // "photo": [
    //   {
    //     "photoID": 1,
    //     "fileName": "https://p0teststorage.blob.core.windows.net/p0testcontainer/portrait-dog-on-black-background-600w-1936666948.jpeg",
    //     "userID": 1
    //   }
    // ]
  

    constructor(private service: PawfinderService){
        this.listOfUsers = [];
        this.filteredListOfUser = [];
    }
    
    ngOnInit(): void {
          this.service.getAllUsers().subscribe(result => {
            this.listOfUsers = result;
            this.filteredListOfUser = result;
             // result.forEach(Users=>Users.userName);
        });
    }
      
    changeTitle()
    {
        this.title = "title has been changed!";
        this.src1 = "https://upload.wikimedia.org/wikipedia/commons/5/56/Hudson_Yards_from_Hudson_Commons_%2895131p%29.jpg";
    }

    changeVisible()
    {
        this.isVisible = !this.isVisible;
    }

   
   
    
//   userID:number=0;
   isSelected:boolean=true;
  
   likeCliked(Users:any){    
       Users.like++
        this.isSelected != this.isSelected ;

    }


}

    
