
p=IP(dst="hackaholic.org/24")/TCP(dport=80, flags="S")
sr(p)