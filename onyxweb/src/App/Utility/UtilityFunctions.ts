import { GenderType } from "../Models/Enums/Gender";

    export function handleGender(gender : GenderType) {
        switch(gender) {
            case GenderType.Female : {
                return "Female";
            }
            case GenderType.Male: {
                return "Male";
            }
            case GenderType.Other: {
                return "Other";
            }
            default: {
                return "Other";
            }
        }
    }

    //Since at this time I am using sqlite, the "DateTime"
    //I am being sent back is actually treated as a string.
    export function handleDate(date: Date) {
        return new Date(date).toISOString().split('T')[0]
    }

