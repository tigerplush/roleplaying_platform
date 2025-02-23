import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router } from '@angular/router';
import { CharacterService } from '../../services/character.service';
import { Character } from '../../interfaces/character';
import { CharacterField } from '../../models/character-field';

@Component({
  selector: 'app-character',
  imports: [ CommonModule, MatButtonModule, MatIconModule ],
  templateUrl: './character.component.html',
  styleUrl: './character.component.scss'
})
export class CharacterComponent {
  character!: Character;
  fields: Map<string, CharacterField> = new Map();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private characterService: CharacterService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id === null) {
      return;
    }
    this.fetchCharacter(id);
  }

  fetchCharacter(id: string) {
    this.characterService.getCharacterById(id).subscribe({
      next: value => {
        this.character = value;
        this.fields.clear();
        for(let field of this.character.fields) {
          this.fields.set(field.name, field);
        }
      },
      error: _ => this.router.navigate(['/not-found'])
    });
  }

  onDelete() {
    this.router.navigate(['/characters'])
  }

  onSave() {

  }
}
