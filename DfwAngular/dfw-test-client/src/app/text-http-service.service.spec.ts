import { TestBed } from '@angular/core/testing';

import { TextHttpServiceService } from './text-http-service.service';

describe('TextHttpServiceService', () => {
  let service: TextHttpServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TextHttpServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
