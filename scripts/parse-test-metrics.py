#!/usr/bin/env python3
import xml.etree.ElementTree as ET
import glob
import json
import os

def parse_test_results():
    trx_files = glob.glob("TestResults/*.trx")
    metrics = {
        "total_tests": 0,
        "passed_tests": 0,
        "failed_tests": 0,
        "skipped_tests": 0,
        "execution_time": 0
    }
    
    for trx_file in trx_files:
        try:
            tree = ET.parse(trx_file)
            root = tree.getroot()
            
            counters = root.find(".//Counters")
            if counters is not None:
                metrics["total_tests"] += int(counters.get("total", 0))
                metrics["passed_tests"] += int(counters.get("passed", 0))
                metrics["failed_tests"] += int(counters.get("failed", 0))
                metrics["skipped_tests"] += int(counters.get("notExecuted", 0))
                
            times = root.find(".//Times")
            if times is not None:
                # Add some time calculation logic here
                pass
                
        except Exception as e:
            print(f"Error parsing {trx_file}: {e}")
    
    return metrics

if __name__ == "__main__":
    metrics = parse_test_results()
    print(json.dumps(metrics, indent=2))
