export interface ParamMaster {
    ID: number;
    CategoryID: number;
    Name: string;
    EnglishName: string;
    FreeField: string;
    IsRequired: string;
    Weighting: number;
    ParamCategory: ParamCategory;

}

export interface ParamCategory {
    ID: number;
    Name: string;
    EnglishName: string;
}