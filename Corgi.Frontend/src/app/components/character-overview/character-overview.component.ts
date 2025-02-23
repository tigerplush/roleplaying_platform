import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { CreateCharacterDialogComponent } from '../create-character-dialog/create-character-dialog.component';
import { GetCharacterDtoV1 } from '../../interfaces/get-character-dto-v1';
import { CharacterService } from '../../services/character.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-character-overview',
  imports: [ MatIconModule, MatButtonModule, RouterModule ],
  templateUrl: './character-overview.component.html',
  styleUrl: './character-overview.component.scss'
})
export class CharacterOverviewComponent {
  characters!: GetCharacterDtoV1[];

  constructor(
    private dialog: MatDialog
    , private characterService: CharacterService
  ) {}

  ngOnInit() {
    this.characterService.getAllCharacters().subscribe({
      next: value => this.characters = value.characters,
    })
  }

  onSelect(value: GetCharacterDtoV1) {

  }

  openNewCharacterDialog() {
    this.dialog.open(CreateCharacterDialogComponent);
  }
}