import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminLayoud } from './admin-layoud';

describe('AdminLayoud', () => {
  let component: AdminLayoud;
  let fixture: ComponentFixture<AdminLayoud>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminLayoud]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminLayoud);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
