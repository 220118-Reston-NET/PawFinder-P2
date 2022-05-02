import { Component, OnInit } from '@angular/core';
import { NavbarService } from '../services/navbar.service';

@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.css']
})
export class UserSettingsComponent implements OnInit {

  hideChart:boolean = false;
  
  listOfInterests:string[] = [];
  WalksButton:string = "inactive";
  BeachesButton:string = "inactive";
  SwimmingButton:string = "inactive";
  FetchButton:string = "inactive";
  SleepingButton:string = "inactive";
  EatingButton:string = "inactive";
  chartToggleButton:string = "material-icons showChart"
  
  //!! Get rid of this eventually
  userID: number = 1;
  //chart visibility is used for both showing the button styling and for storing the user setting in the db.
  chartVisibility: string = "toggle_off";

  constructor(public nav: NavbarService) { }

  ngOnInit(): void {
    this.nav.show();

    //TODO: Add a service to get the user settings from the backend to update this page
    //TODO: The service should toggle every button that the user has currently saved to their profile settings
    //TODO: EXAMPLE: hide like-dislike = false (button should be toggled off) 
    //TODO:          age range 5 (slider should be at 5) 
    //TODO:          interests: walks fetch (both those buttons should be set to active)
    //this.loadUserSettings();
  }

  toggleInterests(selectedInterest:string)
  {
    //for walks button
    if(selectedInterest === "Walks" && this.WalksButton === 'inactive' && this.listOfInterests.length < 3)
    {
      this.WalksButton = 'active';
      this.listOfInterests.push(selectedInterest);
    }
    else if(selectedInterest === "Walks" && this.WalksButton !== 'inactive')
    {
      //remove the element from the list that we are unselecting from our interests
      let tempListOfInterests:string[] = [];
      this.listOfInterests.forEach(element => {
        if(element !== selectedInterest)
        {
          tempListOfInterests.push(element)
        }
      });
      this.listOfInterests = tempListOfInterests;
      this.WalksButton = 'inactive';
    }
      
    //for beaches button
    if(selectedInterest === "Beaches" && this.BeachesButton === 'inactive' && this.listOfInterests.length < 3)
    {
      this.BeachesButton = 'active';
      this.listOfInterests.push(selectedInterest);
    }
    else if(selectedInterest === "Beaches" && this.BeachesButton !== 'inactive')
    {
      //remove the element from the list that we are unselecting from our interests
      let tempListOfInterests:string[] = [];
      this.listOfInterests.forEach(element => {
        if(element !== selectedInterest)
        {
          tempListOfInterests.push(element)
        }
      });
      this.listOfInterests = tempListOfInterests;
      this.BeachesButton = 'inactive';
    }

    //for swimming button
    if(selectedInterest === "Swimming" && this.SwimmingButton === 'inactive' && this.listOfInterests.length < 3)
    {
      this.SwimmingButton = 'active';
      this.listOfInterests.push(selectedInterest);
    }
    else  if(selectedInterest === "Swimming" && this.SwimmingButton !== 'inactive')
    {
      //remove the element from the list that we are unselecting from our interests
      let tempListOfInterests:string[] = [];
      this.listOfInterests.forEach(element => {
        if(element !== selectedInterest)
        {
          tempListOfInterests.push(element)
        }
      });
      this.listOfInterests = tempListOfInterests;
      this.SwimmingButton = 'inactive';
    }

    //for fetch button
    if(selectedInterest === "Fetch" && this.FetchButton === 'inactive' && this.listOfInterests.length < 3)
    {
      this.FetchButton = 'active';
      this.listOfInterests.push(selectedInterest);
    }
    else  if(selectedInterest === "Fetch" && this.FetchButton !== 'inactive')
    {
      //remove the element from the list that we are unselecting from our interests
      let tempListOfInterests:string[] = [];
      this.listOfInterests.forEach(element => {
        if(element !== selectedInterest)
        {
          tempListOfInterests.push(element)
        }
      });
      this.listOfInterests = tempListOfInterests;
      this.FetchButton = 'inactive';
    }

    //for sleeping button
    if(selectedInterest === "Sleeping" && this.SleepingButton === 'inactive' && this.listOfInterests.length < 3)
    {
      this.SleepingButton = 'active';
      this.listOfInterests.push(selectedInterest);
    }
    else  if(selectedInterest === "Sleeping" && this.SleepingButton !== 'inactive')
    {
      //remove the element from the list that we are unselecting from our interests
      let tempListOfInterests:string[] = [];
      this.listOfInterests.forEach(element => {
        if(element !== selectedInterest)
        {
          tempListOfInterests.push(element)
        }
      });
      this.listOfInterests = tempListOfInterests;
      this.SleepingButton = 'inactive';
    }

    //for eating button
    if(selectedInterest === "Eating" && this.EatingButton === 'inactive' && this.listOfInterests.length < 3)
    {
      this.EatingButton = 'active';
      this.listOfInterests.push(selectedInterest);
    }
    else  if(selectedInterest === "Eating" && this.EatingButton !== 'inactive')
    {
      //remove the element from the list that we are unselecting from our interests
      let tempListOfInterests:string[] = [];
      this.listOfInterests.forEach(element => {
        if(element !== selectedInterest)
        {
          tempListOfInterests.push(element)
        }
      });
      this.listOfInterests = tempListOfInterests;
      this.EatingButton = 'inactive';
    }

  }

  showOrHideRatioChart()
  {
    if(this.chartVisibility === "toggle_on")
    {
      this.chartToggleButton = "material-icons showChart";
      this.chartVisibility = "toggle_off";
    }
    else
    {
      this.chartToggleButton = "material-icons hideChart";
      this.chartVisibility = "toggle_on";
    }
  }

  submit()
  {
    //TODO: hitting submit will send the chart information, age range and interests to the db
    //!! way to do interests: if(interest[0] { then add the interest else add "" }) do this for all 3 interest[0],[1],[2]
  }

  loadUserSettings()
  {
    //TODO: will grab all the current user settings based on userId
  }

}
