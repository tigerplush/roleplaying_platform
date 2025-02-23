import { GetCharacterFieldDtoV1 } from "./get-character-field-dto-v1";

export interface GetCharacterDtoV1 {
    id: string;
    name: string;
    fields: GetCharacterFieldDtoV1[];
}
