import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCharacterDialogComponent } from './create-character-dialog.component';

describe('CreateCharacterDialogComponent', () => {
  let component: CreateCharacterDialogComponent;
  let fixture: ComponentFixture<CreateCharacterDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateCharacterDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateCharacterDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
