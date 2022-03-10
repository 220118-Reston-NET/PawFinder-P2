import { Users } from './../models/users.model';
import { FormGroup, FormControl } from '@angular/forms';
import { Component} from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-registor',
  templateUrl: './registor.component.html',
  styleUrls: ['./registor.component.css']
})
export class RegistorComponent {
  
  show:boolean = false;

   registorFormGroup= new FormGroup({
            userID:new FormControl(""),
            userName: new FormControl(),
            uesrPassword:new FormControl(),
            userDBO: new FormControl(),
            userBio:new FormControl(),
            userBreed:new FormControl(),
            userSize:new FormControl()
            
  });

  showPassword()
  {
    this.show = !this.show;
  }

  addUser(p_userGroup:FormGroup){
    let user:Users=
    {
      userID:p_userGroup.get("userID")?.value,
      userName:p_userGroup.get("userName")?.value,
      userPassword:p_userGroup.get("password")?.value,
      userDBO:p_userGroup.get("userDBO")?.value,
      userBio:p_userGroup.get("userBio")?.value,
      userBreed:p_userGroup.get("userBreed")?.value,
      userSize:p_userGroup.get("userSize")?.value,
    }
    // this.service.Add

  }
  constructor(private router: Router) {
  }
    Registor() 
    {
      this.router.navigate(["/registor"]);
     }

}