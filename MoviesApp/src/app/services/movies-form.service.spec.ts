import { TestBed } from '@angular/core/testing';

import { MoviesFormService } from './movies-form.service';

describe('MoviesFormService', () => {
  let service: MoviesFormService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MoviesFormService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
