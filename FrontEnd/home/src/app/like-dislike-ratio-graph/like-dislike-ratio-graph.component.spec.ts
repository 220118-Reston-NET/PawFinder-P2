import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { NgChartsModule } from 'ng2-charts';

import { LikeDislikeRatioGraphComponent } from './like-dislike-ratio-graph.component';

describe('LikeDislikeRatioGraphComponent', () => {
  let component: LikeDislikeRatioGraphComponent;
  let fixture: ComponentFixture<LikeDislikeRatioGraphComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ LikeDislikeRatioGraphComponent ],
      imports: [ NgChartsModule ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LikeDislikeRatioGraphComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
