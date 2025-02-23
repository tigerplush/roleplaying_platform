import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { GetCharacterDtoV1 } from '../interfaces/get-character-dto-v1';
import { AddCharacterDtoV1 } from '../interfaces/add-character-dto-v1';
import { CharacterResponseDtoV1 } from '../interfaces/character-response-dto-v1';
import { Character } from '../interfaces/character';
import { CharacterField } from '../models/character-field';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  private readonly resource: string = 'characters';
  constructor(private http: HttpClient) { }

  getAllCharacters() {
    return this.http.get<CharacterResponseDtoV1>(`${environment.baseUrl}/${this.resource}`);
  }

  getCharacterById(id: string) : Observable<Character> {
    return this.http.get<GetCharacterDtoV1>(`${environment.baseUrl}/${this.resource}/${id}`).pipe(
      map(character => ({
        ...character,
        fields: character.fields.map(CharacterField.fromDTO)
      }))
    );
  }

  createNewCharacter(character: AddCharacterDtoV1) {
    return this.http.post<GetCharacterDtoV1>(`${environment.baseUrl}/${this.resource}`, character);
  }
}
