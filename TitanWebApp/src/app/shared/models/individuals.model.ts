import { Gender } from './genders.model';

export interface Individual {
    ID?: number;
    Code?: string;
    FirstName?: string;
    SecondName?: string;
    ThirdName?: string;
    FourthName?: string;
    GenderID?: number;
    Gender?: Gender;
    BirthDate?: Date;
}
