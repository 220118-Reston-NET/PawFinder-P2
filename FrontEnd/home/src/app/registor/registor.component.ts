import { PawfinderService } from './../services/pawfinder.service';
import { Users } from './../models/users.model';
import { FormGroup, FormControl } from '@angular/forms';
import { Component, OnInit} from '@angular/core';
import { Router } from "@angular/router";
import { NavbarService } from '../services/navbar.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-registor',
  templateUrl: './registor.component.html',
  styleUrls: ['./registor.component.css']
})
export class RegistorComponent implements OnInit{
  
  userGroup= new FormGroup({
    userName: new FormControl(""),
    userPassword:new FormControl(""),
    userDBO: new FormControl(""),
    userBio:new FormControl(""),
    userBreed:new FormControl(""),
    userSize:new FormControl("")
    
   });
  file:any ;
  show:boolean = false;
  
  constructor(private router: Router, private userService: UserService, public nav: NavbarService, public service:PawfinderService) {
  }

  ngOnInit(): void {
    this.nav.hide();
  }

  showPassword()
  {
    this.show = !this.show;
  }

  addUser(p_userGroup:FormGroup){
    // if(p_userGroup.valid){

    // }
    let user:Users=
    {
      // userID:p_userGroup.get("userID")?.value,
      userName:p_userGroup.get("userName")?.value,
      userPassword:p_userGroup.get("userPassword")?.value,
      userDOB:p_userGroup.get("userDOB")?.value,
      userBio:p_userGroup.get("userBio")?.value,
      userBreed:p_userGroup.get("userBreed")?.value,
      userSize:p_userGroup.get("userSize")?.value,
      photo:p_userGroup.get("photo")?.value
    }
    
    this.userService.addUser(user).subscribe();
    this.router.navigate(["/Profile"]);

  }
   onFilechange(event: any)
    {
   console.log(event.target.files[0])
   this.file = event.target.files[0]
   }
 
 upload() 
 {
      if (this.file) {
        this.service.uploadfile(this.file).subscribe(resp => {
          alert("Uploaded")
        })
      } 
        else {
          alert("Please select a file first")
        }
  }

}
