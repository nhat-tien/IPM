export const DATETIME_MIN_VALUE_STR = "0001-01-01T00:00:00";

export function getDateOrNull(datetime: string): Date | null {
    if(datetime === DATETIME_MIN_VALUE_STR) {
      return null;
    } else {
      return new Date(datetime);
    }
  }

export function dateToString(date: Date | null): string {
  if(date != null) {
    date.setUTCHours(0,0,0,0);
    return date.toISOString().replace(/\.[0-9]{3}/, '');
  } else {
    return DATETIME_MIN_VALUE_STR;
  }
}

export function formatDate(formatStr: string, date: Date | null, options?: { isAMPMformat: boolean }): string {
  if(!date) return "";

  const year = date.getFullYear();
  const month = date.getMonth();
  const day = date.getDate();

  const minute = date.getMinutes();
  const second = date.getSeconds();

  let amOrPm = "";
  let hour = date.getHours();

  if(options?.isAMPMformat) {

    amOrPm = hour <= 12 && hour != 0 ? "AM" : "PM";

    if(hour == 0) {
      hour = 12;
    } else if (hour > 12) {
      hour-= 12;
    }
  }

  formatStr = formatStr.replace("Y",`${year}`);
  formatStr = formatStr.replace("m",`${month+1}`);
  formatStr = formatStr.replace("d",`${day}`);
  formatStr = formatStr.replace("H",`${hour < 10 ? "0" + hour : hour}`);
  formatStr = formatStr.replace("M",`${minute < 10 ? "0" + minute : minute}`);
  formatStr = formatStr.replace("s",`${second < 10 ? "0" + second : second}`);
  formatStr = formatStr.replace("AM",`${amOrPm}`);

  return formatStr;
}
