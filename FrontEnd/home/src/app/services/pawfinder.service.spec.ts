import { TestBed } from '@angular/core/testing';

import { PawfinderService } from './pawfinder.service';

describe('PawfinderService', () => {
  let service: PawfinderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PawfinderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
