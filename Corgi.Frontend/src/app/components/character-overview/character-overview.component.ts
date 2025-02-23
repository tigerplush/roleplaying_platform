import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { CreateCharacterDialogComponent } from '../create-character-dialog/create-character-dialog.component';

@Component({
  selector: 'app-character-overview',
  imports: [ MatIconModule, MatButtonModule ],
  templateUrl: './character-overview.component.html',
  styleUrl: './character-overview.component.scss'
})
export class CharacterOverviewComponent {
  characters!: any[];

  constructor(private dialog: MatDialog) {}

  onSelect(value: any) {

  }

  openNewCharacterDialog() {
    this.dialog.open(CreateCharacterDialogComponent);
  }
}