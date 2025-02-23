import { CharacterField } from "../models/character-field";

export interface Character {
    id: string;
    name: string;
    fields: CharacterField[];
}
