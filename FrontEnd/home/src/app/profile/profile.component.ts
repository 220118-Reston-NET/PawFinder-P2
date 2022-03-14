import { Component, OnInit } from '@angular/core';
import { PawfinderService } from './../services/pawfinder.service';
import { Users } from './../models/users.model';
import { ActivatedRoute} from '@angular/router';
import { NavbarService } from '../services/navbar.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
 userName:string | null = "No users Selected";
// Users:PawfinderApi;
 Users: any;
  filteredName:string = "";
    listOfUsers:Users[];
    filteredListOfUser:Users[];
  constructor(private router:ActivatedRoute , private service:PawfinderService, public nav: NavbarService) {
    this.Users={ photo: {
      photoID:"",
      fileName:"",
      userID:""
    }};
    this.listOfUsers = [];
        this.filteredListOfUser = [];
   }

  ngOnInit(): void {
    this.userName = this.router.snapshot.paramMap.get("userName");
    this.service.getAllUsers().subscribe(result=>{
      this.Users=result;
    });
    this.nav.show();
      this.service.getAllUsers().subscribe(result => {
            console.log(result);
            this.listOfUsers = result;
            this.filteredListOfUser = result;
             // result.forEach(Users=>Users.userName);
        });
    
  }
   public set FilteredName(s1:string)
    {
        this.filteredName = s1;
        this.filteredListOfUser = this.filteredName ? this.performFilter(this.filteredName) : this.listOfUsers;
    }

    performFilter(filter:string):Users[]
    {
        filter = filter.toLowerCase();

        let tempListOfUsers:Users[]

        tempListOfUsers = this.listOfUsers.filter((Users:Users) => Users.userName.toLowerCase().indexOf(filter) != -1);

        return tempListOfUsers;
    }

}
