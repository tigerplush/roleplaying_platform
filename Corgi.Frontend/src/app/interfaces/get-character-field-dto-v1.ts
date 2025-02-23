import { FieldType } from "../enums/field-type";

export interface GetCharacterFieldDtoV1 {
    id: string;
    name: string;
    fieldType: FieldType;
    value: string;
    isVisible: boolean;

    evaluate(): string;
}
