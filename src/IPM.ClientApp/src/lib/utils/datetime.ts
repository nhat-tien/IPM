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

export function formatDate(formatStr: string, date: Date | null): string {
  if(!date) return "";

  const year = date.getFullYear();
  const month = date.getMonth();
  const day = date.getDate();
  const hour = date.getHours();
  const minute = date.getMinutes();
  const second = date.getSeconds();

  formatStr = formatStr.replace("Y",`${year}`);
  formatStr = formatStr.replace("m",`${month+1}`);
  formatStr = formatStr.replace("d",`${day}`);
  formatStr = formatStr.replace("H",`${hour}`);
  formatStr = formatStr.replace("M",`${minute}`);
  formatStr = formatStr.replace("s",`${second}`);

  return formatStr;
}
