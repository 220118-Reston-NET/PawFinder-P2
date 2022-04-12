import { Component, ViewChild, OnInit } from '@angular/core';
import DatalabelsPlugin from "chartjs-plugin-datalabels";
import { ChartConfiguration, ChartData, ChartEvent, ChartOptions, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';


@Component({
  selector: 'app-like-dislike-ratio-graph',
  templateUrl: './like-dislike-ratio-graph.component.html',
  styleUrls: ['./like-dislike-ratio-graph.component.css']
})
export class LikeDislikeRatioGraphComponent {
likeDislikeRatio:number[] = [ 0, 0 ];

constructor() { }

ngOnInit(): void{
  this.getNumberOfLikesAndDislikes();
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

getNumberOfLikesAndDislikes()
{
  //TODO: make an api controller request in the back end to get the user's total likes and total dislikes
  //use this to show the number on the chart

  // Takes old data out of the chart
  this.pieChartData.datasets[0].data.pop();
  this.pieChartData.datasets[0].data.pop();

  //puts new data onto the chart
  this.pieChartData.datasets[0].data.push(this.likeDislikeRatio[0], this.likeDislikeRatio[1]);

}

}

