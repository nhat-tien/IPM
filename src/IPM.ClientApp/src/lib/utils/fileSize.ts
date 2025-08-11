

export function getFileSizeFormat(sizeInBytes: number): string {
  const KB = 1024;
  const MB = KB * 1024;
  const GB = MB * 1024;
  const TB = GB * 1024;

  if (sizeInBytes < KB) {
    return sizeInBytes + ' B';
  } else if (sizeInBytes < MB) {
    return (sizeInBytes / KB).toFixed(2) + ' KB';
  } else if (sizeInBytes < GB) {
    return (sizeInBytes / MB).toFixed(2) + ' MB';
  } else if (sizeInBytes < TB) {
    return (sizeInBytes / GB).toFixed(2) + ' GB';
  } else {
    return (sizeInBytes / TB).toFixed(2) + ' TB';
  }
}
