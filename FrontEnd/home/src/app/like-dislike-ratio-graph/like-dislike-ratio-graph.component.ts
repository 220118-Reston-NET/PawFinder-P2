import { Component, ViewChild, OnInit } from '@angular/core';
import DatalabelsPlugin from "chartjs-plugin-datalabels";
import { ChartConfiguration, ChartData, ChartEvent, ChartOptions, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { GlobalComponent } from '../global/global.component';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-like-dislike-ratio-graph',
  templateUrl: './like-dislike-ratio-graph.component.html',
  styleUrls: ['./like-dislike-ratio-graph.component.css']
})

export class LikeDislikeRatioGraphComponent implements OnInit
{

  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;

  likeDislikeRatio:number[] = [ 0, 0 ];
  noInfoToDisplayOnChart: boolean = true;

  constructor(private userService: UserService) { }

  ngOnInit(): void
  {
    this.userService.getLikeToDislikeRatio(GlobalComponent.loggedInUserID).subscribe(result => { 
      this.likeDislikeRatio = result;
      this.updatePieChart();
    })
  }

  // Pie
  public pieChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    plugins: {
      legend: {
        display: true,
        position: 'top',
      },
      datalabels: {
        formatter: (value, ctx) => {
          if (ctx.chart.data.labels) {
            return ctx.chart.data.labels[ctx.dataIndex];
          }
        },
      },
    }
  };
  public pieChartData: ChartData<'pie', number[], string | string[]> = {
    labels: [ [ 'Likes' ], [ 'Dislikes' ]],
    datasets: [ {
      data: [ this.likeDislikeRatio[0], this.likeDislikeRatio[1] ],
      backgroundColor: ['green', 'rgba(255, 0, 0, 0.84)'],
      hoverBackgroundColor: ['lightgreen', 'rgba(255, 0, 0, 0.65)'],
      borderColor: "white",
      hoverBorderColor: "white"
    } ]
  };
  public pieChartType: ChartType = 'pie';
  public pieChartPlugins = [ DatalabelsPlugin ];

  // events
  public chartClicked({ event, active }: { event: ChartEvent, active: {}[] }): void {
    console.log(event, active);
  }

  public chartHovered({ event, active }: { event: ChartEvent, active: {}[] }): void {
    console.log(event, active);
  }


  updatePieChart()
  {
    let likedAmount:number = this.likeDislikeRatio[0];
    let dislikedAmount:number = this.likeDislikeRatio[1];

    if((likedAmount === 0) && (dislikedAmount === 0))
    {
      this.noInfoToDisplayOnChart = true;
    }
    else
    {
      // Takes old data out of the chart
      this.pieChartData.datasets[0].data.pop();
      this.pieChartData.datasets[0].data.pop();
    
      //puts new data onto the chart and shows the chart
      this.pieChartData.datasets[0].data.push(likedAmount, dislikedAmount);

      this.chart?.update();
      this.chart?.render();
    }


  }

}

