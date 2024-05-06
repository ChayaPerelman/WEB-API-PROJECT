import { TestBed } from '@angular/core/testing';

import { GiverService } from './giver.service';

describe('GiverService', () => {
  let service: GiverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GiverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
